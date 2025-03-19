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
class AddNewCustomAttributeToAccountExample
{
    fun addNewCustomAttributeToAccount()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"

        val customAttributeCreateUpdatePayload = CustomAttributeCreateUpdatePayload(
            attributeValues = listOf (),
        )

        try
        {
            val response = CustomAttributesApi().addNewCustomAttributeToAccount(
                accountId = 0,
                _data = customAttributeCreateUpdatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling CustomAttributesApi#addNewCustomAttributeToAccount")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling CustomAttributesApi#addNewCustomAttributeToAccount")
            e.printStackTrace()
        }
    }
}
