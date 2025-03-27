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
class AddNewCategoryToAccountExample
{
    fun addNewCategoryToAccount()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"

        val categoryCreateUpdatePayload = CategoryCreateUpdatePayload(
            locale = "en/es",
        )

        try
        {
            val response = HelpCenterApi().addNewCategoryToAccount(
                accountId = 0,
                portalId = 0,
                _data = categoryCreateUpdatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling HelpCenterApi#addNewCategoryToAccount")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling HelpCenterApi#addNewCategoryToAccount")
            e.printStackTrace()
        }
    }
}
