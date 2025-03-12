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
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"

        val portalCreateUpdatePayload = PortalCreateUpdatePayload(
            archived = null,
            color = "add color HEX string, \"#fffff\"",
            customDomain = "https://chatwoot.help/.",
            headerText = "Handbook",
            homepageLink = "https://www.chatwoot.com/",
            name = null,
            slug = null,
            pageTitle = null,
            accountId = null,
        )

        try
        {
            val response = HelpCenterApi().addNewPortalToAccount(
                accountId = null,
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
