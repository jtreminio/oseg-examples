package oseg.chatwoot_examples

import com.chatwoot.client.infrastructure.*
import com.chatwoot.client.apis.*
import com.chatwoot.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class AddNewPortalToAccountExample
{
    fun addNewPortalToAccount()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"

        val portalCreateUpdatePayload = PortalCreateUpdatePayload(
            color = "add color HEX string, \"#fffff\"",
            customDomain = "https://chatwoot.help/.",
            headerText = "Handbook",
            homepageLink = "https://www.chatwoot.com/",
            config = Serializer.moshi.adapter<Map<String, Any>>().fromJson("""
                {
                    "allowed_locales": [
                        "en",
                        "es"
                    ],
                    "default_locale": "en"
                }
            """)!!,
        )

        try
        {
            val response = HelpCenterApi().addNewPortalToAccount(
                accountId = 0,
                _data = portalCreateUpdatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling HelpCenterApi#addNewPortalToAccount")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling HelpCenterApi#addNewPortalToAccount")
            e.printStackTrace()
        }
    }
}
